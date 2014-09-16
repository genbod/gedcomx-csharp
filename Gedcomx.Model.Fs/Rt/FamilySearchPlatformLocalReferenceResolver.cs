﻿using Gx.Common;
using Gx.Conclusion;
using Gx.Fs.Discussions;
using Gx.Fs.Tree;
using Gx.Fs.Users;
using Gx.Records;
using Gx.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gx.Fs.Rt
{
    public class FamilySearchPlatformLocalReferenceResolver : FamilySearchPlatformModelVisitorBase
    {

        private readonly String resourceId;
        protected ExtensibleData resource;

        public FamilySearchPlatformLocalReferenceResolver(String resourceId)
        {
            this.resourceId = resourceId;
        }

        public static ExtensibleData Resolve(ResourceReference @ref, Gedcomx document)
        {
            if (@ref.Resource == null)
            {
                return null;
            }

            return Resolve(@ref.Resource, document);
        }

        public static ExtensibleData Resolve(Uri @ref, Gedcomx document)
        {
            if (!@ref.ToString().StartsWith("#"))
            {
                return null;
            }

            return Resolve(@ref.ToString().Substring(1), document);
        }

        public static ExtensibleData Resolve(String resourceId, Gedcomx document)
        {
            if (resourceId == null)
            {
                return null;
            }

            FamilySearchPlatformLocalReferenceResolver visitor = new FamilySearchPlatformLocalReferenceResolver(resourceId);
            document.Accept(visitor);
            return visitor.Resource;
        }

        public ExtensibleData Resource
        {
            get
            {
                return resource;
            }
        }

        protected void BindIfNeeded(ExtensibleData candidate)
        {
            if (resource == null && this.resourceId.Equals(candidate.Id))
            {
                this.resource = candidate;
            }
        }

        public override void VisitChildAndParentsRelationship(ChildAndParentsRelationship pcr)
        {
            BindIfNeeded(pcr);
            base.VisitChildAndParentsRelationship(pcr);
        }

        public override void VisitDiscussion(Discussion discussion)
        {
            BindIfNeeded(discussion);
            base.VisitDiscussion(discussion);
        }

        public override void VisitComment(Comment comment)
        {
            BindIfNeeded(comment);
            base.VisitComment(comment);
        }

        public override void VisitGedcomx(Gedcomx gx)
        {
            BindIfNeeded(gx);
            base.VisitGedcomx(gx);
        }

        public override void VisitDocument(Document document)
        {
            BindIfNeeded(document);
            base.VisitDocument(document);
        }

        public override void VisitPlaceDescription(PlaceDescription place)
        {
            BindIfNeeded(place);
            base.VisitPlaceDescription(place);
        }

        public override void VisitEvent(Event @event)
        {
            BindIfNeeded(@event);
            base.VisitEvent(@event);
        }

        public override void VisitEventRole(EventRole role)
        {
            BindIfNeeded(role);
            base.VisitEventRole(role);
        }

        public override void VisitAgent(Gx.Agent.Agent agent)
        {
            BindIfNeeded(agent);
            base.VisitAgent(agent);
        }

        public override void VisitSourceDescription(SourceDescription sourceDescription)
        {
            BindIfNeeded(sourceDescription);
            base.VisitSourceDescription(sourceDescription);
        }

        public override void VisitSourceCitation(SourceCitation citation)
        {
            BindIfNeeded(citation);
            base.VisitSourceCitation(citation);
        }

        public override void VisitCollection(Collection collection)
        {
            BindIfNeeded(collection);
            base.VisitCollection(collection);
        }

        public override void VisitRecordDescriptor(RecordDescriptor recordDescriptor)
        {
            BindIfNeeded(recordDescriptor);
            base.VisitRecordDescriptor(recordDescriptor);
        }

        public override void VisitField(Field field)
        {
            BindIfNeeded(field);
            base.VisitField(field);
        }

        public override void VisitFieldValue(FieldValue fieldValue)
        {
            BindIfNeeded(fieldValue);
            base.VisitFieldValue(fieldValue);
        }

        public override void VisitRelationship(Relationship relationship)
        {
            BindIfNeeded(relationship);
            base.VisitRelationship(relationship);
        }

        protected void visitConclusion(Gx.Conclusion.Conclusion conclusion)
        {
            BindIfNeeded(conclusion);
            base.VisitConclusion(conclusion);
        }

        protected void visitSubject(Subject subject)
        {
            BindIfNeeded(subject);
            base.VisitSubject(subject);
        }

        public void visitPerson(Person person)
        {
            BindIfNeeded(person);
            base.VisitPerson(person);
        }

        public void visitFact(Fact fact)
        {
            BindIfNeeded(fact);
            base.VisitFact(fact);
        }

        public void visitPlaceReference(PlaceReference place)
        {
            BindIfNeeded(place);
            base.VisitPlaceReference(place);
        }

        public void visitDate(DateInfo date)
        {
            BindIfNeeded(date);
            base.VisitDate(date);
        }

        public void visitName(Name name)
        {
            BindIfNeeded(name);
            base.VisitName(name);
        }

        public void visitNameForm(NameForm form)
        {
            BindIfNeeded(form);
            base.VisitNameForm(form);
        }

        public void visitNamePart(NamePart part)
        {
            BindIfNeeded(part);
            base.VisitNamePart(part);
        }

        public void visitGender(Gender gender)
        {
            BindIfNeeded(gender);
            base.VisitGender(gender);
        }

        public void visitSourceReference(SourceReference sourceReference)
        {
            BindIfNeeded(sourceReference);
            base.VisitSourceReference(sourceReference);
        }

        public void visitNote(Note note)
        {
            BindIfNeeded(note);
            base.VisitNote(note);
        }

        public void visitEvidenceReference(EvidenceReference evidenceReference)
        {
            BindIfNeeded(evidenceReference);
            base.VisitEvidenceReference(evidenceReference);
        }

        public void visitUser(User user)
        {
            BindIfNeeded(user);
            base.VisitUser(user);
        }
    }
}
